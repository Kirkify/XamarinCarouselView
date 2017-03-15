using CarouselBehaviors.Events;
using CarouselBehaviors.Models;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarouselBehaviors.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private IEventAggregator ea;

        private IList<Person> people;
        public IList<Person> People
        {
            get { return people; }
            set { SetProperty(ref people, value); }
        }

        private int position;
        public int Position
        {
            get { return position; }
            set { SetProperty(ref position, value); }
        }

        public DelegateCommand MoveLeftCommand => new DelegateCommand(OnMoveLeft, () => Position > 0).ObservesProperty(() => Position);

        private void OnMoveLeft()
        {
            Position = Position - 1;
        }

        public DelegateCommand MoveRightCommand => new DelegateCommand(OnMoveRight, () => Position < People.Count() - 1).ObservesProperty(() => Position);

        private void OnMoveRight()
        {
            Position = Position + 1;
        }

        public DelegateCommand TogglePeopleCommand => new DelegateCommand(OnTogglePeople);

        private void OnTogglePeople()
        {
            if (People.Count() > 3)
            {
                OnlyShowSmartestPeople();
            }
            else
            {
                ShowAllPeople();
            }
        }

        private IList<Person> AllPeople()
        {
            var allPeople = new List<Person>();
            allPeople.Add(new Person() { Name = "Mauro", Id = "1" });
            allPeople.Add(new Person() { Name = "Kirk", Id = "2" });
            allPeople.Add(new Person() { Name = "Sawan", Id = "3" });
            allPeople.Add(new Person() { Name = "Johnson", Id = "4" });
            allPeople.Add(new Person() { Name = "Steve", Id = "5" });
            allPeople.Add(new Person() { Name = "Mary", Id = "6" });
            allPeople.Add(new Person() { Name = "Joe", Id = "7" });
            allPeople.Add(new Person() { Name = "Sarah", Id = "8" });

            return allPeople;
        }
        public MainPageViewModel(IEventAggregator ea)
        {
            this.ea = ea;
            // Show all people on initial load
            ShowAllPeople();
        }

        private void OnlyShowSmartestPeople()
        {
            var updatedPeople = AllPeople().Take(3).ToList();
            var desiredPosition = updatedPeople.Count() - 1;

            People = updatedPeople;
            Position = desiredPosition;
        }

        private void ShowAllPeople()
        {
            var updatedPeople = AllPeople();
            var desiredPosition = updatedPeople.Count() - 1;

            People = updatedPeople;
            Position = desiredPosition;
        }
    }
}
