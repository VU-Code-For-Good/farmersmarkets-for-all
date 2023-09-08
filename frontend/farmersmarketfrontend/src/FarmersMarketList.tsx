import React from 'react';
import { FarmersMarket } from './models/FarmersMarket';
import FarmersMarketCard from './FarmersMarketCard';

interface FarmersMarketListProps {
  marketsList: FarmersMarket[];
}

const FarmersMarketList: React.FC<FarmersMarketListProps> = (markets) => {
  return (
    <div className="mx-8 w-full">
        {/* Render a list of farmers markets with the FarmersMarketCard component */}
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
          {markets.marketsList.map((market) => (
            <FarmersMarketCard key={market.id} market={market} />
          ))}
        </div>
    </div>
  );
};

export default FarmersMarketList;
