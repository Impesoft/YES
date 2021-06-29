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

        public Command CancelTappedCommand => new Command(OnToBeCancelled);
        public Command KeepTappedCommand => new Command(CancelToBeCancelled);

        private bool thereAreTicketsToBeCanceled;

        public bool ThereAreTicketsToBeCancelled
        {
            get => thereAreTicketsToBeCanceled;
            set
            {
                thereAreTicketsToBeCanceled = value;
                OnPropertyChanged(nameof(ThereAreTicketsToBeCancelled));
            }
        }

        private DateTime? expiryDate;
        private List<int> _toBeCancelled;
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

        public List<int> ToBeCancelled
        {
            get => _toBeCancelled;
            set
            {
                _toBeCancelled = value;
                OnPropertyChanged(nameof(ToBeCancelled));
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
            ToBeCancelled = new List<int>();
            ThereAreTicketsToBeCancelled = false;
            UsersTickets = new ObservableCollection<TicketDto>();
            // Task.Run(() => LoadUserWithTickets());
        }

        private void DeleteTicket(TicketDto ToBeCanceledTicket)
        {
            ToBeCancelled.Add(ToBeCanceledTicket.Id);

            //LocalUser.Tickets.Remove(ToBeCanceledTicket);
            CancelCount = ToBeCancelled.Count;
            ThereAreTicketsToBeCancelled = true;
            UsersTickets.Remove(ToBeCanceledTicket);
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

        private async void OnToBeCancelled()
        {
            bool Result = await TicketService.CancelTicketsAsync(ToBeCancelled);
            LoadUserWithTickets();
            ThereAreTicketsToBeCancelled = false;
            ToBeCancelled.Clear();
        }

        private void CancelToBeCancelled()
        {
            ThereAreTicketsToBeCancelled = false;
            ToBeCancelled.Clear();
            LoadUserWithTickets();
        }
    }
}