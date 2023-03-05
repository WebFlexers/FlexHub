function scrollDown(elementId) {
    let element = document.getElementById(elementId);
    element.scrollTop = element.scrollHeight;
    console.log("The element height is " + element.scrollHeight);
}