# CopyCat
A clone of Flappy Bird created with Unity, Photoshop, and Google Firebase*

## Optimizations

Sprites are batched together to reduce draw calls. The Flappy Bird (Cat) doesn't actually move forward. Instead the world, such as the pipes, move to the left and are recycled when off screen. So if you're REALLY good at the game you never have to worry about floating point precision loss :)
All gameobjects are instantiated once and are pooled and reused to maintain constant memory usage and reduce Garbage Collector lag spikes.

## TODO

The sprite atlas can be improved in spacing. There's currently a lot of empty space in the texture
*Upgrade Google Firebase plugin to fix the leaderboard database

## Lessons Learned:

This was my first published app on the Google Play store (was originally uploaded in 2016). I learned everything required to take an app from start to finish using Unity. Also learned how to implement Google Play Services to use features such as leaderboards. However I decided to just use Google Firebase for the leaderboards. For authorization I (at least for now) am using No-Auth to writing to the database. Because I didn't want players to be forced to create an account in order to have their high scores uploaded to the leaderboard.
