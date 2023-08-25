import { useState } from "react"
import Header from "./Header"
import SearchBar from "./SearchBar"
import StateDirectory from "./StateDirectory/StateDirectory"
import React from "react";
import { useNavigate } from 'react-router-dom';
import stateAbbr from "./utils/stateAbbr";

const App = () => {
  const navigate = useNavigate();

  const onStateSelected = (stateName: string) => {
    var stateAbbreviation = stateAbbr(stateName, 'abbr');
    // Redirect to a specific route, for example: `/states/:stateName`
    navigate(`/listmarkets/?state=${stateAbbreviation}`);
  };

  return (
    <>

      <div>
        <Header></Header>
      </div>

      <div>
        <StateDirectory onStateSelectedCallback={onStateSelected}></StateDirectory>
      </div>

      <div className="search-form flex items-center justify-center min-h-screen">
        <SearchBar></SearchBar>
      </div>
    </>
  );
};

export default App;
