import axios from 'axios';
import queryString from 'query-string';

export function accountLogin({ userName, password }) {
    const data = queryString.stringify({
        grant_type: 'password',
        userName,
        password
    });

    try {
        return axios.post('http://localhost:6753/token', data, {
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
        }).then(response => response.data).catch(() => null);
    } catch (error) {
        return error;
    }
}