load("@bazel_tools//tools/build_defs/repo:http.bzl", "http_archive")

http_archive(
  name = "bazel_skylib",
  urls = [
    "https://mirror.bazel.build/github.com/bazelbuild/bazel-skylib/releases/download/1.2.1/bazel-skylib-1.2.1.tar.gz",
    "https://github.com/bazelbuild/bazel-skylib/releases/download/1.2.1/bazel-skylib-1.2.1.tar.gz",
  ],
  sha256 = "f7be3474d42aae265405a592bb7da8e171919d74c16f082a5457840f06054728",
)

load("@bazel_skylib//:workspace.bzl", "bazel_skylib_workspace")

bazel_skylib_workspace()

load("@bazel_tools//tools/build_defs/repo:git.bzl", "git_repository")

git_repository(
  name = "rules_dotnet",
  remote = "https://github.com/bazelbuild/rules_dotnet",
  # branch = "next",
  commit = "b436d580113fa0365e04ee866bec823f3437e731",
  shallow_since = "1662124804 +0000",
)

load(
  "@rules_dotnet//dotnet:repositories.bzl",
  "dotnet_register_toolchains",
  "rules_dotnet_dependencies",
)

rules_dotnet_dependencies()

dotnet_register_toolchains("dotnet", "6.0.300")

load("@rules_dotnet//dotnet:rules_dotnet_nuget_packages.bzl", "rules_dotnet_nuget_packages")

rules_dotnet_nuget_packages()

load("@rules_dotnet//dotnet:paket2bazel_dependencies.bzl", "paket2bazel_dependencies")

paket2bazel_dependencies()

load("//deps:paket.bzl", "paket")

paket()
