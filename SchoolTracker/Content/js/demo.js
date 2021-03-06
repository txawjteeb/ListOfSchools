/**
 * Demo.js
 * Javascript file for O3 scss library demo
 **/

;(function() {

  'use strict';

  var i,
    $popoverLinks   = document.querySelectorAll('[data-popover]'),
    $popovers     = document.querySelectorAll('.popover'),
    entityMapObject   = { "&": "&amp;", "<": "&lt;", ">": "&gt;", '"': '&quot;', "'": '&#39;', "/": '&#x2F;' };

  function init() {
    for (i = 0; i < $popoverLinks.length; i++) $popoverLinks[i].addEventListener('click', openPopover);
    document.addEventListener('click', closePopover);
  }

  function closePopover(e) {
    for (i = 0; i < $popovers.length; i++) $popovers[i].classList.remove('popover-open');
  }

  function openPopover(e) {
    e.preventDefault();
    if (document.querySelector(this.getAttribute('href')).classList.contains('popover-open')) {
      document.querySelector(this.getAttribute('href')).classList.remove('popover-open');
    }
    else {
      closePopover();
      document.querySelector(this.getAttribute('href')).classList.add('popover-open');
    }
    e.stopImmediatePropagation();
  }

  function escapeHtml(string) {
    return String(string).replace(/[&<>"'\/]/g, function(s) {
      return entityMapObject[s];
    });
  }

  init();

}());