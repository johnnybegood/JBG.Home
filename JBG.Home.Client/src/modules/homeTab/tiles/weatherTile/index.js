import sun from './icons/Sun.svg';
import moon from './icons/Moon.svg';
import lightningSun from './icons/Cloud-Lightning.svg';
import lightningMoon from './icons/Cloud-Lightning-Moon.svg';
import drizzleSun from './icons/Cloud-Drizzle.svg';
import drizzleMoon from './icons/Cloud-Drizzle-Moon.svg';
import rainSun from './icons/Cloud-Rain.svg';
import rainMoon from './icons/Cloud-Rain-Moon.svg';
import snowSun from './icons/Cloud-Snow-Sun.svg';
import snowMoon from './icons/Cloud-Snow-Moon.svg';
import fogSun from './icons/Cloud-Fog.svg';
import fogMoon from './icons/Cloud-Fog-Moon.svg';
import cloud from './icons/Cloud.svg';
import cloudMoon from './icons/Cloud-Moon.svg';
import template from './weather.handlebars';

const iconMapping = {
    Clear: { day: sun, night: moon},
    Sun: { day: sun, night: moon},
    Thunderstorm: { day: lightningSun, night: lightningMoon},
    Drizzle: { day: drizzleSun, night: drizzleMoon},
    Rain: { day: rainSun, night: rainMoon},
    Snow: { day: snowSun, night: snowMoon},
    Fog: { day: fogSun, night: fogMoon},
    Clouds: { day: cloud, night: cloudMoon},
}

export default function render({weather}) {
    if (!weather) {
        return "";
    }

    const now = new Date();
    const isDay = weather.sunRise > now && now < weather.sunSet;
    const iconType = isDay ? "day" : "night";

    return template({
        icon: iconMapping[weather.condition][iconType],
        description: weather.description,
        temperature: weather.currentTemperature,
        max: weather.maxTodayTemperature,
        min: weather.minTodayTemperature,
        alert: iconMapping[weather.alert || "Clear"].day
    });
}