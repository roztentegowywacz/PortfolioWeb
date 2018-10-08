// Navigation script
document.querySelector('#toggle').onclick = function() {
    this.classList.toggle('active');
    document.querySelector('#overlay').classList.toggle('open');
  };
  // Navigation script - END

// Initialize Mixitup (gallery and filter)
var containerEl = document.querySelector('[data-ref="mixitup-container"]');

var mixer = mixitup(containerEl, {
    selectors: {
        target: '[data-ref="mixitup-target"]'
    }
});
// Initialize Mixitup - END