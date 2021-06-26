using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using YES.Mobile.Dto;
using YES.Mobile.Enums;
using YES.Mobile.Services;
using YES.Mobile.Views;

namespace YES.Mobile.ViewModels
{
    public class UserDetailViewModel : BaseViewModel
    {
        private int cancelCount;
        public int CancelCount
        {
            get => cancelCount;
            set
            {
                cancelCount = value;
                OnPropertyChanged(nameof(CancelCount));
            }

        }
            public Command CancelTappedCommand => new Command(OnToBeCanceled);

        private bool thereAreTicketsToBeCanceled;

        public bool ThereAreTicketsToBeCanceled
        {
            get => thereAreTicketsToBeCanceled;
            set
            {
                thereAreTicketsToBeCanceled = value;
                OnPropertyChanged(nameof(ThereAreTicketsToBeCanceled));
            }
        }

        private DateTime? expiryDate;
        private List<int> _toBeCanceled;
        private ICollection<TicketDto> usersTickets;

        public ICollection<TicketDto> UsersTickets
        {
            get { return usersTickets; }
            set
            {
                usersTickets = value;
                OnPropertyChanged(nameof(UsersTickets));
            }
        }

        public List<int> ToBeCanceled
        {
            get => _toBeCanceled;
            set
            {
                _toBeCanceled = value;
                OnPropertyChanged(nameof(ToBeCanceled));
            }
        }

        private CustomerWithTicketsDto _localUser;
        public Command<TicketDto> DeleteCommand { get; }

        public CustomerWithTicketsDto LocalUser
        {
            get => _localUser;
            set
            {
                _localUser = value;
                OnPropertyChanged(nameof(LocalUser));
            }
        }

        public ICustomerService CustomerService { get; set; }
        public ITicketService TicketService { get; set; }

        public DateTime? ExpiryDate
        {
            get => expiryDate;
            set
            {
                expiryDate = value;
                OnPropertyChanged(nameof(ExpiryDate));
            }
        }

        public UserDetailViewModel()
        {
            CustomerService = new CustomerService();
            TicketService = new TicketService();
            DeleteCommand = new Command<TicketDto>(DeleteTicket);
            ToBeCanceled = new List<int>();
            ThereAreTicketsToBeCanceled = false;
            UsersTickets = new ObservableCollection<TicketDto>();
            // Task.Run(() => LoadUserWithTickets());
        }

        private void DeleteTicket(TicketDto ToBeCanceledTicket)
        {
            ToBeCanceled.Add(ToBeCanceledTicket.Id);

            //LocalUser.Tickets.Remove(ToBeCanceledTicket);
            UsersTickets.Remove(ToBeCanceledTicket);
            CancelCount = ToBeCanceled.Count;
            ThereAreTicketsToBeCanceled = true;
        }

        public async void LoadUserWithTickets()
        {
            LocalUser = await CustomerService.GetCustomerAsync();
            UsersTickets = LocalUser.Tickets;
            UserTokenDto user = GlobalVariables.LoggedInUser;
            var stream = user.Token;
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(stream);
            var tokenS = jsonToken as JwtSecurityToken;
            expiryDate = tokenS.ValidTo;
            Title = "Logged in as: " + user.Email;
        }

        private async void OnToBeCanceled()
        {
            bool Result = await TicketService.CancelTicketsAsync(ToBeCanceled);
            LoadUserWithTickets();
            ThereAreTicketsToBeCanceled = false;
            // await Shell.Current.GoToAsync("//CalendarPage");
        }
    }
}