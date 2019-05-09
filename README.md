# Unity Dynamic Water Created By Justice Shultz

This project is a very basic demonstration of dynamic water.

The water will rise or lower based on the amount of objects put into it as well as removed from it. This means it will dynamically flood into regions until the water has run out of mass and in game mode you may shoot spheres into the water with left mouse and fill the base up more. If in scene view you may drag the non static walls at run time and let the water flood dynamically, this will also affect the height while taking into account the dynamic objects.

This project also contains dynamic bouyancy so certain layered objects may be affected by the water dynamically.


This system was built to be fast but could use some improvements. Using mesh generation over chunking as well as a better spill method is advised if you plan to use this projects contents.


[Known Bug]
It should be noted that this does not handle world spilling with real physics, so it is best to always contain it within a polygonal region. This can be understood better when opening the project, unmarking a wall as static, and opening the spill area to the world. It may also be achieved by overflowing the pool.
