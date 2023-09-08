import React from 'react';
import StateItem from './StateItem';
import StateChip from './StateChip';

interface stateProps {
  onStateSelectedCallback: (stateName: string) => void;
}

function StateDirectory(props: stateProps) {
    //array of StateItem called statesDirectories
    const statesDirectories: StateItem[] = [];

    statesDirectories.push({name: "Alaska", imageSrc: "/states/alaska.png", link: ""})
    statesDirectories.push({name: "Alabama", imageSrc: "/states/alabama.png", link: ""})
    statesDirectories.push({name: "Arkansas", imageSrc: "/states/arkansas.png", link: ""})
    statesDirectories.push({name: "Arizona", imageSrc: "/states/arizona.png", link: ""})
    statesDirectories.push({name: "California", imageSrc: "/states/california.png", link: ""})
    statesDirectories.push({name: "Colorado", imageSrc: "/states/colorado.png", link: ""})
    statesDirectories.push({name: "Connecticut", imageSrc: "/states/connecticut.png", link: ""})
    statesDirectories.push({name: "Delaware", imageSrc: "/states/delaware.png", link: ""})
    statesDirectories.push({name: "Florida", imageSrc: "/states/florida.png", link: ""})
    statesDirectories.push({name: "Georgia", imageSrc: "/states/georgia.png", link: ""})
    statesDirectories.push({name: "Hawaii", imageSrc: "/states/hawaii.png", link: ""})
    statesDirectories.push({name: "Iowa", imageSrc: "/states/iowa.png", link: ""})
    statesDirectories.push({name: "Idaho", imageSrc: "/states/idaho.png", link: ""})
    statesDirectories.push({name: "Illinois", imageSrc: "/states/illinois.png", link: ""})
    statesDirectories.push({name: "Indiana", imageSrc: "/states/indiana.png", link: ""})
    statesDirectories.push({name: "Kansas", imageSrc: "/states/kansas.png", link: ""})
    statesDirectories.push({name: "Kentucky", imageSrc: "/states/kentucky.png", link: ""})
    statesDirectories.push({name: "Louisiana", imageSrc: "/states/louisiana.png", link: ""})
    statesDirectories.push({name: "Massachusetts", imageSrc: "/states/massachusetts.png", link: ""})
    statesDirectories.push({name: "Maryland", imageSrc: "/states/maryland.png", link: ""})
    statesDirectories.push({name: "Maine", imageSrc: "/states/maine.png", link: ""})
    statesDirectories.push({name: "Michigan", imageSrc: "/states/michigan.png", link: ""})
    statesDirectories.push({name: "Minnesota", imageSrc: "/states/minnesota.png", link: ""})
    statesDirectories.push({name: "Missouri", imageSrc: "/states/missouri.png", link: ""})
    statesDirectories.push({name: "Mississippi", imageSrc: "/states/mississippi.png", link: ""})
    statesDirectories.push({name: "Montana", imageSrc: "/states/montana.png", link: ""})
    statesDirectories.push({name: "North Carolina", imageSrc: "/states/north,carolina.png", link: ""})
    statesDirectories.push({name: "North Dakota", imageSrc: "/states/north,dakota.png", link: ""})
    statesDirectories.push({name: "Nebraska", imageSrc: "/states/nebraska.png", link: ""})
    statesDirectories.push({name: "New Hampshire", imageSrc: "/states/new,hampshire.png", link: ""})
    statesDirectories.push({name: "New Jersey", imageSrc: "/states/new,jersey.png", link: ""})
    statesDirectories.push({name: "New Mexico", imageSrc: "/states/new,mexico.png", link: ""})
    statesDirectories.push({name: "Nevada", imageSrc: "/states/nevada.png", link: ""})
    statesDirectories.push({name: "New York", imageSrc: "/states/newyork.png", link: ""})
    statesDirectories.push({name: "Ohio", imageSrc: "/states/ohio.png", link: ""})
    statesDirectories.push({name: "Oklahoma", imageSrc: "/states/oklahoma.png", link: ""})
    statesDirectories.push({name: "Oregon", imageSrc: "/states/oregon.png", link: ""})
    statesDirectories.push({name: "Pennsylvania", imageSrc: "/states/pennsylvania.png", link: ""})
    statesDirectories.push({name: "Rhode Island", imageSrc: "/states/rhode,island.png", link: ""})
    statesDirectories.push({name: "South Carolina", imageSrc: "/states/south,carolina.png", link: ""})
    statesDirectories.push({name: "South Dakota", imageSrc: "/states/south,dakota.png", link: ""})
    statesDirectories.push({name: "Tennessee", imageSrc: "/states/tennessee.png", link: ""})
    statesDirectories.push({name: "Texas", imageSrc: "/states/texas.png", link: ""})
    statesDirectories.push({name: "Utah", imageSrc: "/states/utah.png", link: ""})
    statesDirectories.push({name: "Virginia", imageSrc: "/states/virginia.png", link: ""})
    statesDirectories.push({name: "Vermont", imageSrc: "/states/vermont.png", link: ""})
    statesDirectories.push({name: "Washington", imageSrc: "/states/washington.png", link: ""})
    statesDirectories.push({name: "Wisconsin", imageSrc: "/states/wisconsin.png", link: ""})
    statesDirectories.push({name: "West Virginia", imageSrc: "/states/west,virginia.png", link: ""})
    statesDirectories.push({name: "Wyoming", imageSrc: "/states/wyoming.png", link: ""})

   const onStateSelected = (stateName: string) => {
      props.onStateSelectedCallback(stateName)
   }
  
   return (
    <div className="states-block__content">
      <h2 className="text-center">State Directories</h2>

      <p className="text-center">
        Select your state
      </p>
      <div className="grid grid-cols-8 gap-2 mx-4">
        {statesDirectories.map((state, index) => (
          <div>
            <StateChip key={index} item={state} onStateSelected={onStateSelected}></StateChip>
          </div>
        ))}
      </div>
    </div>
  );
};

export default StateDirectory;
