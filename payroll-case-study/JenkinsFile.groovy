 
pipeline {
    agent any
    parameters {
        string(name: 'branch', defaultValue: 'teste', description: 'Nome da branch')
    }
    stages {
        stage('Build') {
            
             steps {
                
                echo '########## checkout ##########'
                checkout scm

                echo '########## Restore Nuget Package ##########'
                bat "C:\\Jenkins\\workspace\\nuget.exe restore C:\\Jenkins\\workspace\\Payroll3\\payroll-case-study\\Payroll.sln"

                echo '########## Building... ##########' 
                bat "msbuild.exe C:\\Jenkins\\workspace\\Payroll3\\payroll-case-study\\Payroll.sln" 
             }

        }
        stage('Build + SonarQube analysis') {
            //The tool name "SonarQube Scanner 2.8" needs to match the "Name" field of a SonarQube Installation on the Global Tools Configuration page
            steps {
                script { 
                    def sqScannerMsBuildHome = tool 'SonarScanner-MsBuild'
                    echo "===================================================================="
                    //The name used in the withSonarQubeEnv step needs to match the "Name" field of a SonarQube server defined on the Configure System page.
                    withSonarQubeEnv('SonarQube-server') {
                        echo "${sqScannerMsBuildHome}\\SonarScanner.MSBuild.exe begin /k:payroll /d:sonar.host.url=%SONAR_HOST_URL% /d:sonar.login=%SONAR_AUTH_TOKEN%"
                        // Due to SONARMSBRU-307 value of sonar.host.url and credentials should be passed on command line
                        bat "${sqScannerMsBuildHome}\\SonarScanner.MSBuild.exe begin /k:payroll /d:sonar.host.url=%SONAR_HOST_URL% /d:sonar.login=%SONAR_AUTH_TOKEN%"
                        bat 'MSBuild.exe payroll-case-study\\Payroll.sln /t:Rebuild'
                        bat "${sqScannerMsBuildHome}\\SonarScanner.MSBuild.exe end /d:sonar.login=%SONAR_AUTH_TOKEN%"
                    }
                }
            }
        }
        
        stage('Test') {
            steps {
                echo '########## Testing... ##########'
                bat "nunit3-console.exe C:\\Jenkins\\workspace\\Payroll3\\payroll-case-study\\Test\\bin\\Debug\\Test.dll /result=nunit-result.xml"
            }
        }
        stage('Deploy') {
            steps {
                echo 'Deploying....'
            }
        }
    }

    post {
        success {
            echo 'Pipeline Succeeded'
        }
        failure {
            echo 'Pipeline Failed'
        }
        unstable {
            echo 'Pipeline run marked unstable'
        }       
    }
}