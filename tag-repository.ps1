git config --global user.email "$($env:GIT_EMAIL_ADDRESS)"
git config --global user.name "$($env:GIT_USERNAME)"
git config --global credential.helper store

Add-Content "$env:USERPROFILE\.git-credentials" "https://$($env:GIT_USERNAME):$($env:GIT_PASSWORD)@bitbucket.org`n"

git remote add bitbucket https://$($env:GIT_USERNAME)@bitbucket.org/$($env:APPVEYOR_REPO_NAME).git
git tag $($env:APPVEYOR_BUILD_VERSION) $($env:APPVEYOR_REPO_COMMIT)
git push bitbucket --tags --quiet