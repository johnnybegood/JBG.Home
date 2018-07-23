// Import tabs
import homeTab from "./tabs/homeTab";

export function onLoad() {
    var container = document.getElementById('container');
    container.innerHTML = homeTab();
}