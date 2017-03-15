# XamarinCarouselView
Example app which shows how to fix the carousel view binding incorrectly to the position property  

I was playing around with the Carousel View after a friend told me about an issue he was having with the Carousel not updating 
to the proper position when you update the CarouselViews itemsource property.  I found a temporary work around which could be used
which fixes the problem.  Basically I created a custom event which sends out which page we want to switch to.  
The page where the CarouselView is created listens for this event and sets a position property in its class.  
Then we explicitly listen for the ItemSelected event in the CarouselView where we can manually set the Position property if the event 
was raised prior.  Unfortunately I was only able to get this fix to work on Android.
