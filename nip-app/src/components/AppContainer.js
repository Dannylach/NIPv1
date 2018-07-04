import React, {Component} from 'react';
import SearchForm from './SearchForm';
import LogsTable from './LogsTable';
import ErrorHandler from './ErrorHandler';
import loading from './../images/loading.png';
import NewCompanyForm from './NewCompanyForm';
import EditCompanyForm from './EditCompanyForm';
import LoginForm from './LoginForm';
import Logs from './Logs';
import Card from './Card';

class AppContainer extends Component {

    constructor() {
        super();
        this.state = {
            token: '',
            idLoged: false,
            numberSearched: null,
            company: null,
            isPending: false,
            error: null,
            logs: null,
            adding: false,
            editing: false,
            isCompany: false};
    }

    getNumberSearched = (number) => {
        this.setState({ numberSearched: number })
    }

    handleCompany = (companyResult) => {
        if(companyResult == 'pend') {
            this.setState({ isCompany: false })
        } else if(companyResult.error == null) {
            this.setState({
                company: companyResult,
                isPending: false,
                isCompany: true
            })
        } else  {
            this.setState({
                error: companyResult.error,
                isPending: false,
                company: null,
                isCompany: false
            })
        }
        this.handleSearching();
    }

    handleLogin = (loginResult) => {
        if(loginResult != undefined) this.setState({
            isPending: false,
            isLoged: true,
            token: loginResult.access_token
        });
        else this.setState({
            error: 'Wrong login or password',
            isPending: false
        })
    }

    handleLogs = (logsResult) => {
        this.setState({
            logs: logsResult,
            isPending: false
        })
    }

    handleLoading = () => this.setState({ isPending: true});

    handleAdding = () => {
        this.setState({ adding: true,
            error: null,
            company: null,
            editing: false,
            isCompany: false
        });
    }

    handleSearching = () => {
        this.setState({ adding: false,
            editing: false,
            error: null
        });
    }

    handleEditing = () => {
        this.setState({ adding: false,
            editing: true,
            error: null
        });
    }

    handleLoginOut = () => {
        this.setState({ isLoged: false, error: null })
    }

    render() {
        const { isLoged, error, logs, isCompany, adding, editing, company } = this.state;
        window.onbeforeunload = function() { localStorage.clear();}
        
        return(
            <div>
                <div className="response">
                    
                    { isLoged && !adding && !editing && <span>
                        <input type="button" value="Dodaj firmę" onClick={ () => this.handleAdding()}/>
                        <input type="button" value="Edytuj firmę" onClick={ () => this.handleEditing()}/>
                        <input type="button" value="Wyloguj" onClick={ () => this.handleLoginOut()}/>
                    </span> }
                    
                    { isLoged && !adding && editing && <span>
                        <input type="button" value="Dodaj firmę" onClick={ () => this.handleAdding()}/>
                        <input type="button" value="Wyszukaj firmę" onClick={ () => this.handleSearching()}/>
                        <input type="button" value="Wyloguj" onClick={ () => this.handleLoginOut()}/>
                    </span> }
                    
                    { isLoged && adding && !editing && <span>
                        <input type="button" value="Wyszukaj firmę" onClick={ () => this.handleSearching()}/>
                        <input type="button" value="Edytuj firmę" onClick={ () => this.handleEditing()}/>
                        <input type="button" value="Wyloguj" onClick={ () => this.handleLoginOut()}/>
                    </span> }
                    
                    { !editing && !adding && <div className="searchForm"><SearchForm
                        onReceiveCompanyData={this.handleCompany}
                        onAskingForData={this.handleLoading}
                        onSearchingCompany={this.getNumberSearched}
                        passiveOnReceiveLogs={this.handleLogs}
                        logged={this.logged}/></div> }
                    
                    { isLoged && !editing && adding && <div className="newCompanyForm"><NewCompanyForm
                        onSearchingCompany={this.handleCompany}
                        onSendingData={this.handleLoading}
                        token={this.state.token}/></div> }
                    
                    { isLoged && editing && !adding && isCompany && <div className="editCompanyForm">
                        <EditCompanyForm onAskingForData={this.handleLoading}
                        onSendingData={this.handleLoading}
                        onSearchingCompany={this.handleCompany}
                        searchedNumber={this.state.numberSearched}
                        company={this.state.company}
                        token={this.state.token}/></div> }
                    
                    { isLoged && editing && !adding && !isCompany && <div className="editCompanyForm">
                        Please first find company to edit and then come back.
                        </div> }
                    
                    { !editing && isCompany && <div className="center"><Card card={company}/></div> }
					
                    { !isLoged && <div className="loginForm"><LoginForm
                        onSendingData={this.handleLoading}
                        onReceiveData={this.handleLogin}/></div>}
                    
                    { error && <ErrorHandler errorMessage={error}/> }
                    
                    <span className="loadingPadding">
                        { this.state.isPending && <img src={loading}
                            id="loading_image"
                            className="rotate90"
                            alt="Loading..."/>}
                    </span>
                    
                    {!editing && !adding && <div className="footer">
                        { logs && <LogsTable logs={logs}/> }
                        { !logs && <Logs onReceiveLogData={this.handleLogs} onAskingForData={this.handleLoading}/>}
                    </div>}
                </div>
            </div>
        );
    }
}

export default AppContainer;