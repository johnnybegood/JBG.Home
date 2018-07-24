import './icons';
import template from './weather.handlebars';

export default function render() {
    return template({
        icon: 'Sun',
        temperature: 20,
        max: 30,
        min: 18,
        rain: {
            time: '22:00',
            chance: '20%',
        }
    });
}