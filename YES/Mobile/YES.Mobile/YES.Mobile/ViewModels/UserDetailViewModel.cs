using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using YES.Mobile.Dto;
using YES.Mobile.Enums;
using YES.Mobile.Services;

namespace YES.Mobile.ViewModels
{
    public class UserDetailViewModel : BaseViewModel
    {
        //  public string LocalUser { get; set; }

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
        public List<int> ToBeCanceled;
        private CustomerWithTicketsDto _localUser;
        public Command<int> DeleteCommand { get; }

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
            Task.Run(() => LoadUserWithTickets());
            UserTokenDto user = GlobalVariables.LoggedInUser;
            var stream = user.Token;
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(stream);
            var tokenS = jsonToken as JwtSecurityToken;
            expiryDate = tokenS.ValidTo;
            Title = "Logged in as: " + user.Email;
            DeleteCommand = new Command<int>(DeleteTicket);
            ToBeCanceled = new List<int>();
            ThereAreTicketsToBeCanceled = false;
        }

        private void DeleteTicket(int ToBeCanceledTicketId)
        {
            ToBeCanceled.Add(ToBeCanceledTicketId);

            ThereAreTicketsToBeCanceled = true;
        }

        private async void LoadUserWithTickets()
        {
            LocalUser = await CustomerService.GetCustomerAsync();
        }
    }
}