using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using YES.Mobile.Dto;
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

        public Command<TicketCategoryDto> AddTicketCommand { get; set; }

        public Command<TicketCategoryDto> DeductTicketCommand { get; set; }

        private ObservableCollection<TicketPurchaseDto> ticketPurchasingList;

        public ObservableCollection<TicketPurchaseDto> TicketPurchasingList
        {
            get { return ticketPurchasingList; }
            set
            {
                ticketPurchasingList = value;

                OnPropertyChanged(nameof(TicketPurchasingList));
            }
        }

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

        public EventDetailViewModel()
        {
            Title = "Event Details";
            LoadEventCommand = new Command(LoadEvent);

            AddTicketCommand = new Command<TicketCategoryDto>(OnAddTicket);
            DeductTicketCommand = new Command<TicketCategoryDto>(OnDeductTicket);
            //LoggedInUserId = _customerService.GetLoggedInUser();
            //Customer = await _customerService.GetCustomerByIdAsync(LoggedInUserId)
            CalcTotalPrice();

            //PurchaseSuccesful = false;
        }

        public async void LoadEvent()
        {
            _eventService = new EventService();
            Event = await _eventService.GetEventDetails(EventId);
        }

        private TicketPurchaseDto CreateTicket(TicketCategoryDto categoryDto)
        {
            return new TicketPurchaseDto
            {
                //TicketCustomerId = Customer.Id,
                EventId = Event.Id,
                TicketCategory = categoryDto,
                Amount = 1
            };
        }

        private void OnAddTicket(TicketCategoryDto ticketCategory)
        {
            if (TicketPurchasingList != null)
            {
                foreach (var item in TicketPurchasingList)
                {
                    if (ticketCategory.Id == item.TicketCategory.Id)
                    {
                        item.Amount++;
                        ticketCategory.AvailableAmount--;
                    }
                }
            }
            else
            {
                var newTicket = CreateTicket(ticketCategory);
                TicketPurchasingList.Add(newTicket);
                ticketCategory.AvailableAmount--;
            }

            TotalPrice = CalcTotalPrice();
            AmountOfTicketsToPurchase = CountTotalTickets();
        }

        private void OnDeductTicket(TicketCategoryDto ticketCategory)
        {
        }

        private double CalcTotalPrice()
        {
            double price = 0;
            foreach (var item in TicketPurchasingList)
            {
                price += (item.TicketCategory.Price * item.Amount);
            }
            return price;
        }

        private int CountTotalTickets()
        {
            int amount = 0;
            foreach (var item in TicketPurchasingList)
            {
                amount += item.Amount;
            }

            return amount;
        }
    }
}