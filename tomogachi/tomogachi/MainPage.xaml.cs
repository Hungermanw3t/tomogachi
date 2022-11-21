using System;
using Xamarin.Forms;

namespace tomogachi
{
    public partial class MainPage : ContentPage
    {
        int Hunger = 0;
        int Happy = 200;
        int awakeNess = 200;
        string petName;

        public MainPage()
        {
            InitializeComponent();
            update();
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                PetImage.Rotation -= 5;

                Hunger++;
                Happy--;
                awakeNess--;

                update();
                return true;
            });
        }

        async void update()
        {
            if (Hunger == 200 || Happy == 0 || awakeNess == 0)
            {
                await DisplayAlert("Dead", $"{petName} is dead", "oh no");
            }
            HungerLabel.Text = $"Hunger: {Hunger}";
            HappyLabel.Text = $"Happy: {Happy}";
            awakeLabel.Text = $"Awake: {awakeNess}";
        }

        async void ChangeNameEvent(object sender, EventArgs e)
        {
            petName = await DisplayPromptAsync("What is your pets name", "Is it cheese", "accept", "go away");
            PetNameLabel.Text = petName;
        }

        private void HungerLabel_Clicked(object sender, EventArgs e)
        {
            if (Hunger < 20)
            {
                Hunger = 0;
            }
            else
            {
                Hunger -= 20;
            }
            PetImage.Rotation += 7;
        }

        private void HappyLabel_Clicked(object sender, EventArgs e)
        {
            Happy += 15;
            PetImage.Rotation += 7;
        }

        private void awakeLabel_Clicked(object sender, EventArgs e)
        {
            awakeNess += 25;
            PetImage.Rotation += 7;
        }
    }
}
