import React from 'react';
import {FarmersMarketsApiApi} from './farmersmarketapi/apis/farmers-markets-api-api';
import { Configuration } from './farmersmarketapi/configuration';

function SearchState() {
    const configuration = new Configuration({basePath: 'https://cfafarmersmarket.eastus.cloudapp.azure.com'});
    const api = new FarmersMarketsApiApi(configuration);

    //TODO this will work once CORS is enabled on the API
    api.farmersMarketsStateGet('CA').then((response) => {
      console.log(response.data);
    });

    return (
      <div className="mx-8 w-full">
        <p>Search State</p>
      </div>
    );
  }
  
export default SearchState;