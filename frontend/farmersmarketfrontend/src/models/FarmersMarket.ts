type FarmersMarket = {
    city: string;
    email: string | null;
    id: number;
    name: string;
    operatingDay: string | null;
    operatingMonths: string[] | null;
    phone: string | null;
    socialMedia: string | null;
    state: string;
    streetAddress: string;
    website: string | null;
    zipCode: string;
};

function mapFarmersMarket(marketData: any): FarmersMarket {
    return {
        city: marketData.city,
        email: marketData.email,
        id: marketData.id,
        name: marketData.name,
        operatingDay: marketData.operatingDay,
        operatingMonths: marketData.operatingMonths,
        phone: marketData.phone,
        socialMedia: marketData.socialMedia,
        state: marketData.state,
        streetAddress: marketData.streetAddress,
        website: marketData.website,
        zipCode: marketData.zipCode
    };
  }
  