import { useState } from "react"
import Header from "./Header"
import StateDirectory from "./StateDirectory/StateDirectory"
import ChatBotView from "./chatbot/ChatBot"
import React from "react";
import { useNavigate } from 'react-router-dom';
import stateAbbr from "./utils/stateAbbr";
import ZipSearch from "./zipsearch";

const App = () => {
  const navigate = useNavigate();

  const onStateSelected = (stateName: string) => {
    var stateAbbreviation = stateAbbr(stateName, 'abbr');
    // Redirect to a specific route, for example: `/states/:stateName`
    navigate(`/listmarkets/?state=${stateAbbreviation}`);
  };

  const onZipSelected = (zipCode: string) => {
    // Redirect to a specific route, for example: `/zip/:zipCode`
    navigate(`/listmarkets/?zipcode=${zipCode}`);
  };

  return (
    <>

      <div>
        <Header></Header>
      </div>

      <div>
        <StateDirectory onStateSelectedCallback={onStateSelected}></StateDirectory>
      </div>

      <div className="text-center">
    <h1 className="center-text">Or by Zipcode</h1>
  </div>  
      <br>
      </br>

      <div>
        {/* Use the zipsearch component */}
        <ZipSearch onSubmit={onZipSelected}></ZipSearch>
      </div>
      <div>
        <ChatBotView/>
      </div>
    </>
  );
};

export default App;
