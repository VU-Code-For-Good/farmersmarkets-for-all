import React from 'react';
import { FarmersMarket } from './models/FarmersMarket';

interface FarmersMarketCardProps {
  market: FarmersMarket;
}

const FarmersMarketCard: React.FC<FarmersMarketCardProps> = ({ market }) => {
  return (
    <div className="bg-white shadow-md rounded-md p-4">
      <h2 className="text-lg font-semibold mb-2">{market.name}</h2>
      <p className="text-gray-600 mb-1">{market.streetAddress}</p>
      <p className="text-gray-600 mb-1">
        {market.city}, {market.state} {market.zipCode}
      </p>
      {market.email && <p className="text-blue-500 mb-1">{market.email}</p>}
      {market.phone && <p className="text-gray-600 mb-1">{market.phone}</p>}
      {market.website && (
        <a
          href={market.website}
          target="_blank"
          rel="noopener noreferrer"
          className="text-blue-500 hover:underline"
        >
          {market.website}
        </a>
      )}

      <button className = "float-right hover:bg-green-700 bg-green-500 rounded-full px-4 text-white py-2">
        View Market
      </button>
    </div>
  );
};

export default FarmersMarketCard;
