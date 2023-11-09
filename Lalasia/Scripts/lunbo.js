// Initialize the current slide index
var currentSlide = 0;

// Get the slideshow container and its child elements
var slides = document.getElementsByClassName("slideshow")[0].children;

function changeSlide(n) {
    // Update the current slide index
    currentSlide += n;

    // Check if the current slide index exceeds the total number of slides
    if (currentSlide >= slides.length) {
        currentSlide = 0;
    } else if (currentSlide < 0) {
        currentSlide = slides.length - 1;
    }

    // Hide all slides
    for (var i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }

    // Display the current slide
    slides[currentSlide].style.display = "block";
}

// Automatically change the slide every 5 seconds
setInterval(function () {
    changeSlide(1);
}, 5000);