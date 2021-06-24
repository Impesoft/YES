using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using YES.Mobile.Dto;
using YES.Mobile.Enums;
using YES.Mobile.Services;
using System.Runtime.CompilerServices;

namespace YES.Mobile.ViewModels
{
    [QueryProperty(nameof(EventId), "id")]
    public class EventDetailViewModel : BaseViewModel
    {
        public ICommand LoadEventCommand { get; }

        private int _eventId;
        private static IEventService _eventService { get; set; }
        private EventDto _event;

        public EventDto Event
        {
            get => _event;

            set
            {
                _event = value;
                OnPropertyChanged(nameof(Event));
            }
        }

        public int EventId
        {
            get => _eventId;
            set
            {
                _eventId = value;
                OnPropertyChanged(nameof(EventId));
                LoadEvent();
            }
        }

        private ICustomerService _customerService { get; set; }

        private ITicketService _ticketService { get; set; }

        public Command<TicketCategoryDto> AddTicketCommand { get; set; }

        public Command<TicketCategoryDto> DeductTicketCommand { get; set; }

        public Command ClearPurchaseList { get; set; }

        public Command BuyTickets { get; set; }

        private ObservableCollection<TicketPurchaseDto> ticketsPurchasingList;

        public ObservableCollection<TicketPurchaseDto> TicketsPurchasingList
        {
            get { return ticketsPurchasingList; }
            set
            {
                ticketsPurchasingList = value;

                OnPropertyChanged(nameof(TicketsPurchasingList));
            }
        }

        public UserTokenDto LoggedInUser { get; set; }
        public CustomerWithTicketsDto Customer { get; set; }

        private double totalPrice;

        public double TotalPrice
        {
            get { return totalPrice; }
            set
            {
                totalPrice = value;
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        private int amountOfTicketsToPurchase;

        public int AmountOfTicketsToPurchase
        {
            get { return amountOfTicketsToPurchase; }
            set
            {
                amountOfTicketsToPurchase = value;
                OnPropertyChanged(nameof(AmountOfTicketsToPurchase));
            }
        }

        private bool buyableList;

        public bool BuyableList
        {
            get { return buyableList; }
            set
            {
                buyableList = value;
                OnPropertyChanged(nameof(BuyableList));
            }
        }

        private bool eventPassed;

        public bool EventPassed
        {
            get { return eventPassed; }
            set
            {
                eventPassed = value;
                OnPropertyChanged(nameof(EventPassed));
            }
        }

        public EventDetailViewModel()
        {
            Title = "Event Details";
            CheckDate();
            LoadEventCommand = new Command(LoadEvent);

            AddTicketCommand = new Command<TicketCategoryDto>(OnAddTicket);
            DeductTicketCommand = new Command<TicketCategoryDto>(OnDeductTicket);

            ClearPurchaseList = new Command(OnCancelPurchase);

            LoggedInUser = GlobalVariables.LoggedInUser;

            TicketsPurchasingList = new ObservableCollection<TicketPurchaseDto>();
            CalcTotalPrice();
            SetCustomer();

            BuyableList = false;

            _ticketService = new TicketService();
        }

        private void CheckDate()
        {
            if (Event.EventInfo.EventDate < DateTime.Now)
            {
                EventPassed = false;
            }
            else
            {
                EventPassed = true;
            }
        }

        public async void LoadEvent()
        {
            _eventService = new EventService();
            Event = await _eventService.GetEventDetails(EventId);
        }

        public async void SetCustomer()
        {
            _customerService = new CustomerService();
            Customer = await _customerService.GetCustomerAsync();
        }

        private TicketPurchaseDto CreateTicket(TicketCategoryDto categoryDto)
        {
            return new TicketPurchaseDto
            {
                TicketCustomerId = Customer.Id,
                EventId = Event.Id,
                TicketCategory = categoryDto,
                Amount = 1
            };
        }

        private void OnAddTicket(TicketCategoryDto ticketCategory)
        {
            bool itemFound = false;
            foreach (var item in TicketsPurchasingList)
            {
                if (ticketCategory.Id == item.TicketCategory.Id)
                {
                    item.Amount++;
                    itemFound = true;
                    ticketCategory.AvailableAmount--;
                }
            }
            if (!itemFound)
            {
                var newTicket = CreateTicket(ticketCategory);
                TicketsPurchasingList.Add(newTicket);
                ticketCategory.AvailableAmount--;
            }

            TotalPrice = CalcTotalPrice();
            AmountOfTicketsToPurchase = CountTotalTickets();

            CheckList();
        }

        private void OnDeductTicket(TicketCategoryDto categoryDto)
        {
            var category = TicketsPurchasingList.ToList().FirstOrDefault(x => x.TicketCategory == categoryDto);
            if (category != null)
            {
                if (category.Amount > 1)
                {
                    category.Amount--;
                    Event.TicketCategories.FirstOrDefault(x => x.Id == category.TicketCategory.Id).AvailableAmount++;
                }
                else
                {
                    TicketsPurchasingList.Remove(category);
                    Event.TicketCategories.FirstOrDefault(x => x.Id == category.TicketCategory.Id).AvailableAmount++;
                }

                TotalPrice = CalcTotalPrice();
                AmountOfTicketsToPurchase = CountTotalTickets();
            }

            CheckList();
        }

        private double CalcTotalPrice()
        {
            double price;
            if (TicketsPurchasingList == null)
            {
                price = 0;
            }
            else
            {
                price = 0;
                foreach (var item in TicketsPurchasingList)
                {
                    price += (item.TicketCategory.Price * item.Amount);
                }
            }

            return price;
        }

        private int CountTotalTickets()
        {
            int amount = 0;
            foreach (var item in TicketsPurchasingList)
            {
                amount += item.Amount;
            }

            return amount;
        }

        private void OnCancelPurchase()
        {
            LoadEvent();
            TotalPrice = 0;
            TicketsPurchasingList.Clear();
        }

        private void CheckList()
        {
            if (TicketsPurchasingList.Count > 0 && Event.EventInfo.EventDate < DateTime.Now)
            {
                BuyableList = true;
            }
            else
            {
                BuyableList = false;
            }
        }
    }
}