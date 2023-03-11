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

https://stackoverflow.com/questions/41635841/manipulating-canvas-children-c-sharp-wpf
https://stackoverflow.com/questions/40323022/how-can-i-capture-an-entire-image-from-a-canvas
https://www.codeproject.com/Questions/824429/How-can-I-get-an-Image-to-render-on-a-WPF-Canvas
https://learn.microsoft.com/en-us/dotnet/desktop/wpf/windows/how-to-open-common-system-dialog-box?view=netdesktop-7.0
https://learn.microsoft.com/en-us/dotnet/desktop/wpf/get-started/create-app-visual-studio?view=netdesktop-7.0
https://learn.microsoft.com/en-us/dotnet/api/system.windows.controls.canvas?view=windowsdesktop-7.0
https://stackoverflow.com/questions/6059894/how-draw-rectangle-in-wpf
https://learn.microsoft.com/en-us/dotnet/desktop/wpf/graphics-multimedia/how-to-paint-an-area-with-a-solid-color?view=netframeworkdesktop-4.8
