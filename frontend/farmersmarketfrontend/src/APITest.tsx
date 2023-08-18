import React, {useState} from 'react';
import {FarmersMarketsApiApi} from './farmersmarketapi/apis/farmers-markets-api-api';
import { Configuration } from './farmersmarketapi/configuration';

function APITest() {
    const configuration = new Configuration({basePath: 'https://cfafarmersmarket.eastus.cloudapp.azure.com'});
    const api = new FarmersMarketsApiApi(configuration);

    const [apiWorks, setApiWorks] = useState(false);

    //TODO this will work once CORS is enabled on the API
    api.farmersMarketsStateGet('CA').then((response) => {
      console.log(response);
      setApiWorks(true);
    });

    return (
      <div className="mx-8 w-full">
        {/* If api works * show api works p tag*/}
        {apiWorks && <p className="text-green-500">API works!</p>}
      </div>
    );
  }
  
export default APITest;