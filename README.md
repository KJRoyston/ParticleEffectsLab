Particle System in Unity

What is a Particle System?

 

There are three main elements that a game artist would usually create – 2D images, 3D models, and particle systems. Particle systems are designed to create visual effects which involve the control of large numbers of rather small moving objects. They are usually defined with a sequence of events in order to control the order of movement. The most common examples are fire and smoke.

Create a Basic Particle System

  

Open the main scene. Feel free to hit play and look at the cool fireworks

From *GameObject*, choose *Effect* and create a *Particle System*. What you'll see is a default particle system with a playback panel in the corner:

 ![](Particle Systems_images/image_0.png)

Selecting the particle system, on the Inspector you will see a whole bunch of options:

![](Particle Systems_images/image_1.png)

The names should be self-explanatory. Please feel free to play around with each option to see the effect.

Create A Sparkler

Today let's try to create a sparkler to go with the fireworks. Provided for you is a handle that can be dragged around the screen by the mouse.

The first thing you should do is attach the particle system to the sparkler object. To do this you can just drag the particle system over the sparkler in the hierarchy tab and it will become a child of the sparkler. This means that they will move together. Make sure after attaching that you reset the position of the particle system to where you want it (0,0) should work nicely here.

![](Particle Systems_images/image_2.png)

 

You will notice it is already starting to look like a sparkler but the particles move with the handle. To fix this set simulation space to world:

![](Particle Systems_images/image_3.png)

Local means all the positions of the particle are relative to where the particle system is currently located. This means if we move the sparkler it will cause everything to move, which is not what we want here. Feel free to also change the gravity modifier if you want your particles to fall downwards. 

Try to mess around with the settings to create a believable sparkler effect. Here is a gif of what we created for reference. If you get stuck check out our settings for reference, you can also just ask us directly!

![](Particle Systems_images/image_4.gif)

![](Particle Systems_images/image_5.png)![](Particle Systems_images/image_6.png)

  

 

