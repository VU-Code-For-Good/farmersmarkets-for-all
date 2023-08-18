import React, { useEffect, useState } from "react";
import StateItem from "./StateItem";


interface stateProps {
    item: StateItem;
    onStateSelected: (stateName: string) => void;
}


function StateChip(props: stateProps) {
    let stateInfo = props.item;
    let stateName = stateInfo.name;
    let stateImageSrc = stateInfo.imageSrc;
    let link = stateInfo.link;

    const [isSelected, setIsSelected] = useState(false);
    
    //when isSelected is true, call onStateSelected with stateName
    useEffect(() => {
        if (isSelected) {
            props.onStateSelected(stateName);
        }
    }, [isSelected, stateName, props]);

    const handleClick = (evt) => {
        evt.preventDefault();
        setIsSelected(true);
    }

    return (
        <a onClick = {handleClick} href={link} rel="noopener noreferrer" className="inline-block rounded-full bg-gray-200 text-gray-800 px-3 py-1.5 text-sm font-medium hover:bg-gray-300 transition duration-300">
            <img src={stateImageSrc} alt={stateName} className="w-8 h-8 inline-block mr-1.5" />
            {stateName}
      </a>
    )
}

export default StateChip;