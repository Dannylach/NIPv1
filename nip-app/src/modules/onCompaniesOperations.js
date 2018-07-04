import axios from 'axios';
import queryString from 'query-string';

export function searchCompany({ companyId }) {
    return axios.get('http://localhost:6753/api/Companies/SearchCompany', {
        params: {
            id: companyId
        },
        withCredentials: false
    }).then(response => response.data.Result).catch(() => null);
}

export function addCompany({ Nip, Krs, Regon, Name,
    Street, HouseNumber, PostalCode, City, Rating }) {
    return axios.post('http://localhost:6753/api/Companies/AddCompany', {
        params: {
            nip: Nip,
            krs: Krs,
            regon: Regon,
            name: Name,
            street: Street,
            houseNumber: HouseNumber,
            postalCode: PostalCode,
            city: City,
            rating: Rating
        },
        withCredentials: true
    }).then(response => response.data).catch(() => null);
}

export function editCompany({ Nip, Krs, Regon, Name,
    Street, HouseNumber, PostalCode, City, Rating, token }) {
        
    const data = queryString.stringify({
        Nip: Nip,
        Krs: Krs,
        Regon: Regon,
        Name: Name,
        Street: Street,
        HouseNumber: HouseNumber,
        PostalCode: PostalCode,
        City: City,
        Rating: Rating
    });

    return axios('http://localhost:6753/api/Companies/EditCompany', data,
    {headers: { 'Authorization' : 'bearer ' + {token}}
    }, {withCredentials: false}).then(response => response.data).catch(() => null);
}