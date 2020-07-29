import React, { useContext, useEffect } from 'react';
import { Grid } from 'semantic-ui-react';
import ProfileHeader from './ProfileHeader';
import ProfileContent from './ProfileContent';
import { RootStoreContext } from '../../app/stores/rootStore';
import { RouteComponentProps } from 'react-router-dom';
import LoadingComponents from '../../app/layout/LoadingComponents';
import { observer } from 'mobx-react-lite';

interface RouteParams {
        username: string;
}

interface IProps extends RouteComponentProps<RouteParams> {}

const ProfilePage: React.FC<IProps> = ({match}) => {
    const rootStore = useContext(RootStoreContext);
    const {loadingProfile, profile, loadProfile, follow, unfollow, isCurrentUser, loading, setActiveTab} = rootStore.profileStore;

    useEffect(() => {
        loadProfile(match.params.username)

    }, [loadProfile, match])

    if (loadingProfile) return <LoadingComponents content='Loading Profile'/>

    return (
        <Grid>
            <Grid.Column width={16}>
                <ProfileHeader profile={profile!} follow={follow} unfollow={unfollow} isCurrentUser={isCurrentUser} loading={loading}/>   
                <ProfileContent setActiveTab={setActiveTab}/>
            </Grid.Column>
        </Grid>
    )
}

export default observer(ProfilePage)