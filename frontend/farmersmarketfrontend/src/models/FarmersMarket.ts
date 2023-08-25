import { FarmersMarketApiModelsFarmersMarket } from "../farmersmarketapi/models";

export type FarmersMarket = {
    city: string;
    email: string | null;
    id: number;
    name: string;
    //operatingDay: string | null;
    //operatingMonths: string[] | null;
    phone: string | null;
    //socialMedia: string | null;
    state: string;
    streetAddress: string;
    website: string | null;
    zipCode: string;
};

export function mapFarmersMarket(marketData: FarmersMarketApiModelsFarmersMarket): FarmersMarket {
    return {
        city: marketData.city as string,
        email: marketData.email as string,
        id: marketData.id as number,
        name: marketData.name as string,
        //operatingDay: marketData.operatingDay,
        //operatingMonths: marketData.operatingMonths,
        phone: marketData.phone as string,
        //socialMedia: marketData.socialMedia as string,
        state: marketData.state as string,
        streetAddress: marketData.streetAddress as string,
        website: marketData.website as string,
        zipCode: marketData.zipCode as string,
    };
}
  