import React, {useState} from 'react';
import {FarmersMarketsApiApi} from './farmersmarketapi/apis/farmers-markets-api-api';
import { Configuration } from './farmersmarketapi/configuration';
import { FarmersMarketApiModelsFarmersMarket} from './farmersmarketapi/models';
import { FarmersMarket, mapFarmersMarket } from './models/FarmersMarket';
import FarmersMarketCard from './FarmersMarketCard';
import FarmersMarketList from './FarmersMarketList';

function APITest() {
    const configuration = new Configuration({basePath: 'https://cfafarmersmarket.eastus.cloudapp.azure.com'});
    const api = new FarmersMarketsApiApi(configuration);

    const [apiWorks, setApiWorks] = useState(false);
    const [farmersMarkets, setFarmersMarkets] = useState<FarmersMarket[]>([]); //TODO: change to [FarmersMarket

    //TODO this will work once CORS is enabled on the API
    if (!apiWorks){
      api.farmersMarketsStateGet('CA').then((response) => {
        //map to list of FarmersMarket
        var responseData = response.data.farmersMarkets as (FarmersMarketApiModelsFarmersMarket[]);
        //map resonsedata to list of FarmersMarket
        var farmersMarkets = responseData.map(mapFarmersMarket);
        //set state
        setFarmersMarkets(farmersMarkets);

        console.log(farmersMarkets);
        setApiWorks(true);
      });
    }
    
    return (
      <div className="mx-8 w-full">
        {/* Render a list of farmers markets with the FarmersMarketCard component */}
        <FarmersMarketList marketsList={farmersMarkets} />
      </div>
    );
  }
  
export default APITest;