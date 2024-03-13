var ijsRuntimeExtensions = {

    getBoundingRect: (elementId) => {
        let selector = `#${elementId}`;
        let element = document.querySelector(selector);
        var rect = element.getBoundingClientRect();
        return rect;
    },
}