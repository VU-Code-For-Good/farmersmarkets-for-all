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
import globalAxios, { AxiosResponse, AxiosInstance, AxiosRequestConfig } from 'axios';
import { Configuration } from '../configuration';
// Some imports not used depending on template conditions
// @ts-ignore
import { BASE_PATH, COLLECTION_FORMATS, RequestArgs, BaseAPI, RequiredError } from '../base';
import { FarmersMarketApiModelsModelApiResponse } from '../models';
/**
 * FarmersMarketsApiApi - axios parameter creator
 * @export
 */
export const FarmersMarketsApiApiAxiosParamCreator = function (configuration?: Configuration) {
    return {
        /**
         * 
         * @summary GetFarmersMarketsByState
         * @param {string} state 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        farmersMarketsStateGet: async (state: string, options: AxiosRequestConfig = {}): Promise<RequestArgs> => {
            // verify required parameter 'state' is not null or undefined
            if (state === null || state === undefined) {
                throw new RequiredError('state','Required parameter state was null or undefined when calling farmersMarketsStateGet.');
            }
            const localVarPath = `/farmersMarkets/{state}`
                .replace(`{${"state"}}`, encodeURIComponent(String(state)));
            // use dummy base URL string because the URL constructor only accepts absolute URLs.
            const localVarUrlObj = new URL(localVarPath, 'https://example.com');
            let baseOptions;
            if (configuration) {
                baseOptions = configuration.baseOptions;
            }
            const localVarRequestOptions :AxiosRequestConfig = { method: 'GET', ...baseOptions, ...options};
            const localVarHeaderParameter = {} as any;
            const localVarQueryParameter = {} as any;

            const query = new URLSearchParams(localVarUrlObj.search);
            for (const key in localVarQueryParameter) {
                query.set(key, localVarQueryParameter[key]);
            }
            for (const key in options.params) {
                query.set(key, options.params[key]);
            }
            localVarUrlObj.search = (new URLSearchParams(query)).toString();
            let headersFromBaseOptions = baseOptions && baseOptions.headers ? baseOptions.headers : {};
            localVarRequestOptions.headers = {...localVarHeaderParameter, ...headersFromBaseOptions, ...options.headers};

            return {
                url: localVarUrlObj.pathname + localVarUrlObj.search + localVarUrlObj.hash,
                options: localVarRequestOptions,
            };
        },
        /**
         * 
         * @summary GetFarmersMarketsByZipcode
         * @param {string} zipCode 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        farmersMarketsZipCodeGet: async (zipCode: string, options: AxiosRequestConfig = {}): Promise<RequestArgs> => {
            // verify required parameter 'zipCode' is not null or undefined
            if (zipCode === null || zipCode === undefined) {
                throw new RequiredError('zipCode','Required parameter zipCode was null or undefined when calling farmersMarketsZipCodeGet.');
            }
            const localVarPath = `/farmersMarkets/{zipCode}`
                .replace(`{${"zipCode"}}`, encodeURIComponent(String(zipCode)));
            // use dummy base URL string because the URL constructor only accepts absolute URLs.
            const localVarUrlObj = new URL(localVarPath, 'https://example.com');
            let baseOptions;
            if (configuration) {
                baseOptions = configuration.baseOptions;
            }
            const localVarRequestOptions :AxiosRequestConfig = { method: 'GET', ...baseOptions, ...options};
            const localVarHeaderParameter = {} as any;
            const localVarQueryParameter = {} as any;

            const query = new URLSearchParams(localVarUrlObj.search);
            for (const key in localVarQueryParameter) {
                query.set(key, localVarQueryParameter[key]);
            }
            for (const key in options.params) {
                query.set(key, options.params[key]);
            }
            localVarUrlObj.search = (new URLSearchParams(query)).toString();
            let headersFromBaseOptions = baseOptions && baseOptions.headers ? baseOptions.headers : {};
            localVarRequestOptions.headers = {...localVarHeaderParameter, ...headersFromBaseOptions, ...options.headers};

            return {
                url: localVarUrlObj.pathname + localVarUrlObj.search + localVarUrlObj.hash,
                options: localVarRequestOptions,
            };
        },
    }
};

/**
 * FarmersMarketsApiApi - functional programming interface
 * @export
 */
export const FarmersMarketsApiApiFp = function(configuration?: Configuration) {
    return {
        /**
         * 
         * @summary GetFarmersMarketsByState
         * @param {string} state 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async farmersMarketsStateGet(state: string, options?: AxiosRequestConfig): Promise<(axios?: AxiosInstance, basePath?: string) => Promise<AxiosResponse<FarmersMarketApiModelsModelApiResponse>>> {
            const localVarAxiosArgs = await FarmersMarketsApiApiAxiosParamCreator(configuration).farmersMarketsStateGet(state, options);
            return (axios: AxiosInstance = globalAxios, basePath: string = BASE_PATH) => {
                const axiosRequestArgs :AxiosRequestConfig = {...localVarAxiosArgs.options, url: basePath + localVarAxiosArgs.url};
                return axios.request(axiosRequestArgs);
            };
        },
        /**
         * 
         * @summary GetFarmersMarketsByZipcode
         * @param {string} zipCode 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async farmersMarketsZipCodeGet(zipCode: string, options?: AxiosRequestConfig): Promise<(axios?: AxiosInstance, basePath?: string) => Promise<AxiosResponse<FarmersMarketApiModelsModelApiResponse>>> {
            const localVarAxiosArgs = await FarmersMarketsApiApiAxiosParamCreator(configuration).farmersMarketsZipCodeGet(zipCode, options);
            return (axios: AxiosInstance = globalAxios, basePath: string = BASE_PATH) => {
                const axiosRequestArgs :AxiosRequestConfig = {...localVarAxiosArgs.options, url: basePath + localVarAxiosArgs.url};
                return axios.request(axiosRequestArgs);
            };
        },
    }
};

/**
 * FarmersMarketsApiApi - factory interface
 * @export
 */
export const FarmersMarketsApiApiFactory = function (configuration?: Configuration, basePath?: string, axios?: AxiosInstance) {
    return {
        /**
         * 
         * @summary GetFarmersMarketsByState
         * @param {string} state 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async farmersMarketsStateGet(state: string, options?: AxiosRequestConfig): Promise<AxiosResponse<FarmersMarketApiModelsModelApiResponse>> {
            return FarmersMarketsApiApiFp(configuration).farmersMarketsStateGet(state, options).then((request) => request(axios, basePath));
        },
        /**
         * 
         * @summary GetFarmersMarketsByZipcode
         * @param {string} zipCode 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async farmersMarketsZipCodeGet(zipCode: string, options?: AxiosRequestConfig): Promise<AxiosResponse<FarmersMarketApiModelsModelApiResponse>> {
            return FarmersMarketsApiApiFp(configuration).farmersMarketsZipCodeGet(zipCode, options).then((request) => request(axios, basePath));
        },
    };
};

/**
 * FarmersMarketsApiApi - object-oriented interface
 * @export
 * @class FarmersMarketsApiApi
 * @extends {BaseAPI}
 */
export class FarmersMarketsApiApi extends BaseAPI {
    /**
     * 
     * @summary GetFarmersMarketsByState
     * @param {string} state 
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof FarmersMarketsApiApi
     */
    public async farmersMarketsStateGet(state: string, options?: AxiosRequestConfig) : Promise<AxiosResponse<FarmersMarketApiModelsModelApiResponse>> {
        return FarmersMarketsApiApiFp(this.configuration).farmersMarketsStateGet(state, options).then((request) => request(this.axios, this.basePath));
    }
    /**
     * 
     * @summary GetFarmersMarketsByZipcode
     * @param {string} zipCode 
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof FarmersMarketsApiApi
     */
    public async farmersMarketsZipCodeGet(zipCode: string, options?: AxiosRequestConfig) : Promise<AxiosResponse<FarmersMarketApiModelsModelApiResponse>> {
        return FarmersMarketsApiApiFp(this.configuration).farmersMarketsZipCodeGet(zipCode, options).then((request) => request(this.axios, this.basePath));
    }
}
