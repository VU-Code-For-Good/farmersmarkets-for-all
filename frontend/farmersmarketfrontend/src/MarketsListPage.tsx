import React, { useState } from 'react';
import { FarmersMarket, mapFarmersMarket } from './models/FarmersMarket';
import FarmersMarketCard from './FarmersMarketCard';
import { Configuration } from './farmersmarketapi/configuration';
import { FarmersMarketsApiApi } from './farmersmarketapi/apis/farmers-markets-api-api';
import { FarmersMarketApiModelsFarmersMarket } from './farmersmarketapi/models';
import FarmersMarketList from './FarmersMarketList';
import { useLocation } from 'react-router-dom';
import ZipcodeSearch from './ZipcodeSearch';

function MarketsListPage() {

    const configuration = new Configuration({ basePath: 'https://cfafarmersmarket.eastus.cloudapp.azure.com' });
    const api = new FarmersMarketsApiApi(configuration);

    const [apiWorks, setApiWorks] = useState(false);
    const [farmersMarkets, setFarmersMarkets] = useState<FarmersMarket[]>([]); //TODO: change to [FarmersMarket

    const location = useLocation();

    //check if state in search params
    const searchParams = new URLSearchParams(location.search);

    const state: string | null = searchParams.get('state');
    const zipcode: string | null = searchParams.get('zipcode'); //e.g 65203


    //TODO this will work once CORS is enabled on the API
    if (!apiWorks) {
        if (state != null){
            api.farmersMarketsStateGet(state).then((response) => {
                //map to list of FarmersMarket
                var responseData = response.data.farmersMarkets as (FarmersMarketApiModelsFarmersMarket[]);
                //map resonsedata to list of FarmersMarket
                var farmersMarkets = responseData.map(mapFarmersMarket);
                //set state
                setFarmersMarkets(farmersMarkets);
    
                console.log(farmersMarkets);
                setApiWorks(true);
            });
        }else if (zipcode != null){
            api.farmersMarketsZipCodeGet(zipcode).then((response) => {
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

       
    }

    return (
        <div className="">
            <div className="mx-8 flex justify-between items-center">
                <h1 className="text-lg">Viewing Markets for {state || zipcode}</h1>
                <div>
                    {zipcode == null ? <ZipcodeSearch selectedState={state} /> : null}
                </div>
            </div>
           
            {/* Tailwind divider */}
            <div className="mx-8 my-4 border-t border-black"></div>

            {/* Render a list of farmers markets with the FarmersMarketCard component */}
            <div className = "mb-8">
                <FarmersMarketList marketsList={farmersMarkets} />
            </div>
        </div>
    );

}

export default MarketsListPage;
