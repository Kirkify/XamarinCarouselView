using System;
using CarouselBehaviors.Events;
using Prism.Events;
using Xamarin.Forms;

namespace CarouselBehaviors.Views
{
    public partial class MainPage : ContentPage
    {
        private IEventAggregator ea;
        private int position = -1;

        public MainPage(IEventAggregator ea)
        {
            this.ea = ea;
            InitializeComponent();
        }

        private void SetCarouselPosition(int position)
        {
            this.position = position;
        }

        private void CarouselView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (position != -1)
            {
                Carousel.Position = position;
                position = -1;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ea.GetEvent<PeopleListUpdatedEvent>().Subscribe(SetCarouselPosition);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ea.GetEvent<PeopleListUpdatedEvent>().Unsubscribe(SetCarouselPosition);
        }
    }
}
