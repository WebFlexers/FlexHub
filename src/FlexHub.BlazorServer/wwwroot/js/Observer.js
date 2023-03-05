window.Observer = {
    observer: null,
    executing: false, // add a flag to indicate whether the method is executing

    Initialize: function (component, observerTargetId) {
        this.observer = new IntersectionObserver(entries => {
            if (!this.executing) { // only execute if the flag is not set
                this.executing = true; // set the flag
                component.invokeMethodAsync('OnIntersection')
                    .then(() => this.executing = false); // reset the flag when the method is finished
            }
        });

        let element = document.getElementById(observerTargetId);
        if (element == null) throw new Error("Target was not found");

        this.observer.observe(element);
    }
};