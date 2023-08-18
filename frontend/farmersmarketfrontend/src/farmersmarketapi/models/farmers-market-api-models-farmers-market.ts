/* tslint:disable */
/* eslint-disable */
/**
 * Farmer's Markets - OpenAPI 3.0
 * Farmer's Markets - OpenAPI 3.0 (ASP.NET 6)
 *
 * OpenAPI spec version: 1.0.11
 * 
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */
import { FarmersMarketApiModelsOperatingDay } from './farmers-market-api-models-operating-day';
import { FarmersMarketApiModelsSocialMedia } from './farmers-market-api-models-social-media';
/**
 * 
 * @export
 * @interface FarmersMarketApiModelsFarmersMarket
 */
export interface FarmersMarketApiModelsFarmersMarket {
    /**
     * 
     * @type {number}
     * @memberof FarmersMarketApiModelsFarmersMarket
     */
    id?: number | null;
    /**
     * 
     * @type {string}
     * @memberof FarmersMarketApiModelsFarmersMarket
     */
    name?: string | null;
    /**
     * 
     * @type {Array<FarmersMarketApiModelsOperatingDay>}
     * @memberof FarmersMarketApiModelsFarmersMarket
     */
    operatingDay?: Array<FarmersMarketApiModelsOperatingDay> | null;
    /**
     * 
     * @type {Array<string>}
     * @memberof FarmersMarketApiModelsFarmersMarket
     */
    operatingMonths?: Array<string> | null;
    /**
     * 
     * @type {string}
     * @memberof FarmersMarketApiModelsFarmersMarket
     */
    phone?: string | null;
    /**
     * 
     * @type {string}
     * @memberof FarmersMarketApiModelsFarmersMarket
     */
    streetAddress?: string | null;
    /**
     * 
     * @type {string}
     * @memberof FarmersMarketApiModelsFarmersMarket
     */
    city?: string | null;
    /**
     * 
     * @type {string}
     * @memberof FarmersMarketApiModelsFarmersMarket
     */
    state?: string | null;
    /**
     * 
     * @type {string}
     * @memberof FarmersMarketApiModelsFarmersMarket
     */
    zipCode?: string | null;
    /**
     * 
     * @type {string}
     * @memberof FarmersMarketApiModelsFarmersMarket
     */
    email?: string | null;
    /**
     * 
     * @type {string}
     * @memberof FarmersMarketApiModelsFarmersMarket
     */
    website?: string | null;
    /**
     * 
     * @type {Array<FarmersMarketApiModelsSocialMedia>}
     * @memberof FarmersMarketApiModelsFarmersMarket
     */
    socialMedia?: Array<FarmersMarketApiModelsSocialMedia> | null;
}
