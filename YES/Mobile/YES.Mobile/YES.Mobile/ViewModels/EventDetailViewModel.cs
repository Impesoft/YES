using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using YES.Mobile.Dto;
using YES.Mobile.Enums;
using YES.Mobile.Services;

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

        public Command<TicketCategoryDto> AddTicketCommand { get; set; }

        public Command<TicketCategoryDto> DeductTicketCommand { get; set; }

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

        public int AmountOfTicketsToPurchase { get; set; }
        public bool PurchaseSuccesful { get; set; } = false;

        public EventDetailViewModel()
        {
            Title = "Event Details";
            LoadEventCommand = new Command(LoadEvent);

            AddTicketCommand = new Command<TicketCategoryDto>(OnAddTicket);
            DeductTicketCommand = new Command<TicketCategoryDto>(OnDeductTicket);

            LoggedInUser = GlobalVariables.LoggedInUser;

            TicketsPurchasingList = new ObservableCollection<TicketPurchaseDto>();
            CalcTotalPrice();
            SetCustomer();
            PurchaseSuccesful = false;
        }

        public async void LoadEvent()
        {
            _eventService = new EventService();
            Event = await _eventService.GetEventDetails(EventId);
        }

        public async void SetCustomer()
        {
            _customerService = new CustomerService();
            Customer = await _customerService.GetCustomerByIdAsync(LoggedInUser);
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
            PurchaseSuccesful = false;

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
    }
}