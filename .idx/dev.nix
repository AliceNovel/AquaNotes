# To learn more about how to use Nix to configure your environment
# see: https://firebase.google.com/docs/studio/customize-workspace
{ pkgs, ... }: {
  # Which nixpkgs channel to use.
  channel = "unstable"; # or "stable-24.05"
  # Use https://search.nixos.org/packages to find packages
  packages = [ pkgs.dotnet-sdk_10 ];
  # Sets environment variables in the workspace
  env = { };
  idx = {
    # Search for the extensions you want on https://open-vsx.org/ and use "publisher.id"
    extensions = [
      "muhammad-sammy.csharp"
      "ms-dotnettools.vscode-dotnet-runtime"
    ];
    # Enable previews and customize configuration
    previews = {
      enable = true;
      previews = {
        web = {
          command = [ "dotnet" "watch" "--project=src/AquaNotes/AquaNotes.csproj" "--urls=http://localhost:$PORT" "--pathbase=/AquaNotes" ];
          manager = "web";
        };
      };
    };
  };
}
