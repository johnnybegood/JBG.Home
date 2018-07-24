import homeTab from "./modules/homeTab";
import menu from "./modules/menu";

export function onLoad() {
    let container = document.getElementById('container');
    container.appendChild(homeTab());

    let sidebar = document.getElementById('sidebar');
    sidebar.innerHTML = menu();
}