import todayTile from "./tiles/todayTile";
import weatherTile from "./tiles/weatherTile";
import './tiles.css';

const tiles = [ todayTile, weatherTile ];

export default function render() {
    let grid = document.createElement('div');
    grid.classList.add('tile-grid');
    grid.innerHTML = tiles.reduce((prev, tile) => {
        return prev + tile();
    }, ''); 

    return grid;
}