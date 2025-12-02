'use strict';


/**
 * toggle active class on header
 * when clicked nav-toggle-btn
 */

const header = document.querySelector("[data-header]");
const navToggleBtn = document.querySelector("[data-menu-toggle-btn]");

navToggleBtn.addEventListener("click", function () {
    header.classList.toggle("active");
});



/**
 * toggle ctx-menu when click on card-menu-btn
 */

const menuBtn = document.querySelectorAll("[data-menu-btn]");

for (let i = 0; i < menuBtn.length; i++) {
    menuBtn[i].addEventListener("click", function () {
        this.nextElementSibling.classList.toggle("active");
    });
}

//const menuBtn = document.querySelectorAll("[data-menu-btn]");
//const ctxMenu = document.querySelector(".ctx-menu");

//// Add click event listener to menu buttons
//for (let i = 0; i < menuBtn.length; i++) {
//    menuBtn[i].addEventListener("click", function () {
//        ctxMenu.classList.toggle("active");
//    });
//}

//// Add mouseleave event listener to ctx-menu element
//ctxMenu.addEventListener("mouseleave", function () {
//    ctxMenu.classList.remove("active");
//});




/**
 * load more btn loading spin toggle
 */

const loadMoreBtn = document.querySelector("[data-load-more]");

loadMoreBtn.addEventListener("click", function () {
    this.classList.toggle("active");
});
