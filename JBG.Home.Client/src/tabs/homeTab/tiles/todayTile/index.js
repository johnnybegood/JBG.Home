import template from './today.handlebars';
import format from 'date-fns/format';
import nl from 'date-fns/locale/nl';

export default function render() {
    var today = new Date();

    return template({
        weekday: format(today, 'dddd', { locale: nl }),
        day: format(today, 'DD', { locale: nl }),
        month: format(today, 'MMMM', { locale: nl }),
        year: format(today, 'YYYY', { locale: nl }),
    });
}