import axios from 'axios';
import todayTile from './tiles/todayTile';
import weatherTile from './tiles/weatherTile';
import loadingIcon from '../../icons/loader.svg'
import './tiles.css';

const tiles = [ todayTile, weatherTile ];
const grid = document.createElement('div');

function updateGrid(response) {
    grid.innerHTML = tiles.reduce((prev, tile) => {
        return prev + tile({...response.data});
    }, ''); 
}

export default function render() {
    grid.classList.add('tile-grid');
    grid.innerHTML = `<img src="${loadingIcon}" alt="loading.." class="loader" />`

    axios.get('/api/dashboard')
        .then(updateGrid);

    return grid;
}