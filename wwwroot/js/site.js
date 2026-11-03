// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

(function(){
 const items=document.querySelectorAll('.section-heading,.course-card,.category-tile,.dashboard-stat,.feature-card,.learning-steps,.bottom-cta');
 const reduced=window.matchMedia&&window.matchMedia('(prefers-reduced-motion: reduce)').matches;
 items.forEach((el,i)=>{el.classList.add('reveal-on-scroll');el.style.transitionDelay=(i%4*60)+'ms';});
 if(reduced||!('IntersectionObserver'in window)){items.forEach(el=>el.classList.add('is-visible'));return;}
 const observer=new IntersectionObserver(entries=>entries.forEach(e=>{if(e.isIntersecting){e.target.classList.add('is-visible');observer.unobserve(e.target);}}),{threshold:.12});
 items.forEach(el=>observer.observe(el));
})();
