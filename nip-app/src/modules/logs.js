import axios from 'axios';

export function updateLogs({ companyId }) {
    return axios.get('http://localhost:6753/api/Companies/UpdateLogs',
    {
        params: {
            id: companyId
        },
        withCredentials: false
    }).then(response => response.data).catch(() => null);
}

export function getLogs() {
    return axios.get('http://localhost:6753/api/Companies/GetLogs',
    {
        withCredentials: false
    }).then(response => response.data).catch(() => null);
}
