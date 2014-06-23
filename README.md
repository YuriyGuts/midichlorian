Midichlorian
============

A Visual Studio extension that allows to write code and automate the IDE using MIDI musical instruments.

See the details in my blog post: [Programming on a Keyboard... a Piano Keyboard](http://elekslabs.com/2014/06/programming-on-a-keyboard-a-piano-keyboard.html)

[Demo on YouTube](http://youtu.be/1H7JuYqfFAE)

[Visual Studio Gallery Page](http://visualstudiogallery.msdn.microsoft.com/bdca1405-565a-472d-9ad4-af03b6df8961)


## How It Works

You configure the extension to perform certain tasks when the specified notes or chords are played on a MIDI device. These tasks may include entering text, performing builds, running unit tests, etc.

![Screenshot from Visual Studio Options](/assets/VSOptionsScreenshot.png)

The extension attaches to an active Code Editor window and starts listening to events from a MIDI device. Once the events are captured, the extension matches them against the profile and executes the mapped Visual Studio commands.

## Credits

This extension uses [midi-dot-net](http://code.google.com/p/midi-dot-net/) library by Tom Lokovic. In order to integrate it into a Visual Studio package, I had to create a custom-built strongly named version of the library.

## Contributing

The `master` branch of Midichlorian is built using VS SDK 2013 and has been tested on Visual Studio 2013. Also, the project contains the `vs2012` branch with a version of Midichlorian backported to VS SDK 2012. Since `vs2012` will not introduce features specific only to VS 2012, it is often rebased on top of `master`.
