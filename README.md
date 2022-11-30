# Loupedeck OSC

## THIS PLUGIN HAS BEEN ABONDONED!
After a couple of days playing with the loupedeck API, and with my current *(in)*experience with C#, I have decided to abandon this project.

I may come back to this / the loupedeck in general in the future if the SDK gets updated to allow for more precise user input.

### Limitations
Currently, it seems that the Loupedeck SDK 5.3.1 does not allow for multiple user input fields. This makes it quite problematic for adding multiple arguments to the OSC messages.

My quick way to overcome that, is to type out the full OSC Address / Message in the Loupedeck input field.

    127.0.0.1:55555|/address hello world
The loupedeck will then parse each section out.

### Where it currently stands
The limitations below are mostly because of my own lack of time / understanding of the C# Library
 - All argument will be sent as Strings
 - Only one argument per message is allowed

### Future
Again, I make come back to this project in the future if the SDK gets updated. However, my hopes that maybe someone else will pick up where I left off, although I realize the progress I made on this was pretty negligible.

The Loupedeck seems to be very promising, however, due to the popularity of the Streamdeck, [Bitfocus Companion](https://bitfocus.io/companion), and now the release of the new [Streamdeck with knobs](https://www.theverge.com/2022/11/15/23453527/elgato-stream-deck-plus-announcement) (as well as a rumored hardware release from Bitfocus) It seems a tad futile to continue down the Loupedeck path (for now)

#### Dependencies
[Sharp OSC by ValdemarOrn](https://github.com/ValdemarOrn/SharpOSC)


