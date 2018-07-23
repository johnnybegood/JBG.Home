import todayTile from "./tiles/todayTile/index.js";

export default function render() {
    var tiles = [ todayTile ];
    var content = tiles.reduce((prev, tile) => {
        return prev + tile();
    }, ''); 

    return content;
}