# FinalcoverAssignment
Small application for drawing rectangles on an image.

Running .exe file in the given folder will launch the program. The user is able to select an image file, open the file, and draw rectangles on the image. 
The image will open in a "Paint" window, which has a minimal UI for the user to select colors and save the altered image to a new file.
There are six colors for the user to select from. The user can click on a color and then click and drag the mouse to draw a rectangle of that color.
They can also click on an already drawn rectangle, then click on a color to change the color of that rectangle. 
Users can click on an already drawn rectangle and hold the button down while moving the mouse to drag and drop the rectagnles. 
Users can also double click on a rectangle to delete it. Finally, the user can click the "Save As" button to save the image to a new file, and the "Exit" button to exit 
the program without saving. Users can drag rectangles on top of other rectangles and draw on top of other rectangles.

I was able to finish all of the requirements except for requirement that the user be able to reshape the rectangles by dragging the edges. I had difficulty trying to 
figure out how I would be able to know when the user was clicking on an edge or a corner, and how I would go about reshaping the image. I tried finding a way to use the
size of a clicked rectangle to check where exactly on the shape the user was clicking, and if it was close to the "edge" of the shape, update the appropriate X/Y or width/height values
for the rectangle. However I could not get this to work. I wasn't sure how I could capture which direction the mouse was moving, either. I was also not able to implement 
being able to edit the shapes after saving the image to a new file. 

Resources: 

