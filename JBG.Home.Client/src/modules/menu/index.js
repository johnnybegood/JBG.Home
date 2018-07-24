import template from './menu.handlebars';
import './menu.css';
import homeIcon from './icons/home.svg';
import homeIconAlt from './icons/home-alt.svg';
import appIcon from './icons/app.svg';
import appIconAlt from './icons/app-alt.svg';

const menuItems = [
    { route: '', name: 'Home', icon: homeIcon, iconHover: homeIconAlt },
    { route: 'apps', name: 'Applications', icon: appIcon, iconHover: appIconAlt }
]

export default function render() {
    return template({menuItems});
}