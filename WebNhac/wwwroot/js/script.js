let slideIndex = 0;
const slides = document.querySelector('.sponsor-slide');
const slideItems = document.querySelectorAll('.sponsor-item');

function plusSlides(n) {
    showSlides(slideIndex += n);
}

function showSlides(n) {
    if (n >= slideItems.length) {
        slideIndex = 0;
    } else if (n < 0) {
        slideIndex = slideItems.length - 1;
    }

    slides.style.transform = `translateX(-${slideIndex * 177}px)`;
}